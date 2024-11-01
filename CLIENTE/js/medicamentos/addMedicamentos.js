document.addEventListener("DOMContentLoaded", function() {
    
    const selects = {
        marcas: document.getElementById("marcas"),
        laboratorios: document.getElementById("laboratorios"),
        monodrogas: document.getElementById("monodrogas"),
        presentaciones: document.getElementById("presentaciones")
    };

    const idMed = document.getElementById("idMedAddForm")

    function loadId(){
        fetch("https://localhost:44379/api/Medicamento/LastId")
            .then(response =>response.json())
            .then(data =>{
                idMed.value = data + 1;
                console.log(data)
            })
            .catch(error => console.error("Error al cargar el id", error))
    }

    function loadMarcas(select) {
        fetch("https://localhost:44379/api/Marca")
            .then(response => response.json())
            .then(data => {
                select.innerHTML = '<option selected>Seleccionar</option>';
                data.forEach(item => {
                    const option = document.createElement("option");
                    option.value = item.idMarca; 
                    option.textContent = item.nombreMarca; 
                    select.appendChild(option);
                });
            })
            .catch(error => console.error("Error al cargar opciones:", error));
    }

    function loadLaboratorios(select) {
        fetch("https://localhost:44379/api/Laboratorio")
            .then(response => response.json())
            .then(data => {
                select.innerHTML = '<option selected>Seleccionar</option>';
                data.forEach(item => {
                    const option = document.createElement("option");
                    option.value = item.idLaboratorio; 
                    option.textContent = item.nombreLaboratorio; 
                    select.appendChild(option);
                });
            })
            .catch(error => console.error("Error al cargar opciones:", error));
    }

    function loadMonodrogas(select) {
        fetch("https://localhost:44379/api/Monodroga")
            .then(response => response.json())
            .then(data => {
                select.innerHTML = '<option selected>Seleccionar</option>';
                data.forEach(item => {
                    const option = document.createElement("option");
                    option.value = item.idMonodroga; 
                    option.textContent = item.monodroga1; 
                    select.appendChild(option);
                });
            })
            .catch(error => console.error("Error al cargar opciones:", error));
    }

    function loadPresentaciones(select) {
        fetch("https://localhost:44379/api/Presentacion")
            .then(response => response.json())
            .then(data => {
                select.innerHTML = '<option selected>Seleccionar</option>';
                data.forEach(item => {
                    const option = document.createElement("option");
                    option.value = item.idPresentacion; 
                    option.textContent = item.nombrePresentacion; 
                    select.appendChild(option);
                });
            })
            .catch(error => console.error("Error al cargar opciones:", error));
    }

    loadMarcas(selects.marcas);
    loadLaboratorios(selects.laboratorios);
    loadMonodrogas(selects.monodrogas)
    loadPresentaciones(selects.presentaciones)
    loadId();


});

document.getElementById("btn-addMed").addEventListener("click", function() {

    const idMedicamento = document.getElementById("idMedAddForm").value;
    const nombreComercial = document.getElementById("nameMedAddForm").value;
    const idMonodroga = document.getElementById("monodrogas").value;
    const idLaboratorio = document.getElementById("laboratorios").value;
    const idMarca = document.getElementById("marcas").value;
    const idPresentacion = document.getElementById("presentaciones").value;
    const descripcion = document.getElementById("descripcionMedAddForm").value;
    const precio = parseFloat(document.getElementById("precioMedAddForm").value);


    const ventaLibre = document.querySelector('input[name="ventaLibre"]:checked').value;
    const activo = document.querySelector('input[name="activo"]:checked').value;


    const medicamento = {
        idMedicamento: idMedicamento,
        nombreComercial: nombreComercial,
        idMonodroga: idMonodroga,
        idLaboratorio: idLaboratorio,
        idMarca: idMarca,
        idPresentacion: idPresentacion,
        descripcion: descripcion,
        precio: precio,
        ventaLibre: ventaLibre == "Sí" ? true : false,
        activo: activo == "Sí" ? true : false
    };


    fetch("https://localhost:44379/api/Medicamento", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(medicamento)
    })
    .then(response => {
        if (response.ok) {
            console.log("Medicamento agregado con éxito");
            window.location.href = "/pages/medicamentos.html"

        } else {
            console.log("Error al agregar el medicamento");
        }
    })
    .catch(error => console.error("Error en la solicitud:", error));
});
