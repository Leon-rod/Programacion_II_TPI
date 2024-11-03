export function loadMarcas(select, selectedId = null) {
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
            if (selectedId) {
                select.value = selectedId;
            }

        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export function loadLaboratorios(select, selectedId = null) {
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
            if (selectedId) {
                select.value = selectedId;
            }
        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export function loadMonodrogas(select, selectedId = null) {
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
            if (selectedId) {
                select.value = selectedId;
            }
        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export function loadPresentaciones(select, selectedId = null) {
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
            if (selectedId) {
                select.value = selectedId;
            }
        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

