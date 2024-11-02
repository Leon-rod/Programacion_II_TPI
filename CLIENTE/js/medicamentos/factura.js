document.addEventListener("DOMContentLoaded", () => {
    const $clientSelect = document.getElementById("cliente");
    const $employeeSelect = document.getElementById("empleado");
    fetch("https://localhost:44379/api/Cliente")
    .then(response =>{
        if (response.ok){
            return response.json();
        }
    })
    .then(data => {
        data.forEach(item => {
            const option = document.createElement("option");
            option.value = item.idCliente; 
            option.textContent = `${item.apellido} ${item.nombre}`; 
            $clientSelect.appendChild(option);
        });
    })
    .catch(error => console.error("Error al cargar opciones:", error));

    fetch("https://localhost:44379/api/PersonalEstablecimiento")
    .then(response =>{
        if (response.ok){
            return response.json();
        }
    })
    .then(data => {
        data.forEach(item => {
            const option = document.createElement("option");
            option.value = item.idPersonalCargosEstablecimientos; 
            option.textContent = `${item.idPersonalNavigation.apellido} ${item.idPersonalNavigation.nombre} - ${item.idEstablecimientoNavigation.nombre}`; 
            $employeeSelect.appendChild(option);
        });
    })
    .catch(error => console.error("Error al cargar opciones:", error));
})