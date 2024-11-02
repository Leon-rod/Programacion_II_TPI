import { loadLaboratorios, loadMarcas, loadPresentaciones, loadMonodrogas } from "./medicamentos.js";

document.addEventListener("DOMContentLoaded", function() {
    const id = localStorage.getItem("medicamentoId");

    // Referencias a los elementos del formulario
    const idMedicamento = document.getElementById("idMedEditForm");
    const nombreComercial = document.getElementById("nameMedEditForm");
    const idMonodroga = document.getElementById("monodrogas");
    const idLaboratorio = document.getElementById("laboratorios");
    const idMarca = document.getElementById("marcas");
    const idPresentacion = document.getElementById("presentaciones");
    const descripcion = document.getElementById("descripcionMedEditForm");
    const precio = document.getElementById("precioMedEditForm");
    const ventaLibreSi = document.querySelector('input[name="ventaLibre"][value="true"]');
    const ventaLibreNo = document.querySelector('input[name="ventaLibre"][value="false"]');
    const activoSi = document.querySelector('input[name="activo"][value="true"]');
    const activoNo = document.querySelector('input[name="activo"][value="false"]');

    // Verifica si hay un ID en localStorage
    if (!id) {
        console.error("No se encontró el ID del medicamento en localStorage.");
        return;
    }

    // Obtener los datos del medicamento por su ID
    fetch(`https://localhost:44379/api/Medicamento/${id}`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then(response => response.json())
    .then(data => {
        // Asigna los valores obtenidos a los campos del formulario
        idMedicamento.value = data.idMedicamento;
        nombreComercial.value = data.nombreComercial;
        idMonodroga.value = data.idMonodroga;
        loadMonodrogas(idMonodroga)
        //idMonodroga.textContent = data.idMonodrogaNavigation.idMonodroga
        idLaboratorio.value = data.idLaboratorio;
        idMarca.value = data.idMarca;
        idPresentacion.value = data.idPresentacion;
        descripcion.value = data.descripcion;
        precio.value = data.precio;

        // Marcar el radio button correspondiente para ventaLibre
        if (data.ventaLibre) {
            ventaLibreYes.checked = true;
        } else {
            ventaLibreNo.checked = true;
        }

        // Marcar el radio button correspondiente para activo
        if (data.activo) {
            activoYes.checked = true;
        } else {
            activoNo.checked = true;
        }
    })
    .catch(error => console.error("Error al obtener el medicamento:", error));
});
