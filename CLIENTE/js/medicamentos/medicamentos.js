import {ShowResult, ShowResultError} from './toast.js';
import { loadLaboratorios, loadMarcas, loadMonodrogas, loadPresentaciones } from './auxMedicamentos.js';

document.addEventListener("DOMContentLoaded", function() {

    const medicamentoUrl = "https://localhost:44379/api/Medicamento";

    const selects = {
        marcas: document.getElementById("marcas"),
        laboratorios: document.getElementById("laboratorios"),
        monodrogas: document.getElementById("monodrogas"),
        presentaciones: document.getElementById("presentaciones")
    };



    loadMarcas(selects.marcas);
    loadLaboratorios(selects.laboratorios);
    loadMonodrogas(selects.monodrogas)
    loadPresentaciones(selects.presentaciones)


    function loadMedicamentos() {
        fetch(medicamentoUrl)
            .then(response => response.json())
            .then(data => {
                const tableBody = document.getElementById("tableBody");
                tableBody.innerHTML = ""; 

                data.forEach(medicamento => {
                    const row = document.createElement("tr");

                    const nombreCell = document.createElement("td");
                    nombreCell.textContent = medicamento.nombreComercial;

                    
                    const precioCell = document.createElement("td");
                    precioCell.textContent = `$${medicamento.precio.toFixed(2)}`;

                    const monodrogaCell = document.createElement("td");
                    monodrogaCell.textContent = medicamento.idMonodrogaNavigation.monodroga1;

                    const marcaCell = document.createElement("td");
                    marcaCell.textContent = medicamento.idMarcaNavigation.nombreMarca;

                    const descripcionCell = document.createElement("td");
                    descripcionCell.textContent = medicamento.descripcion

                    const labCell = document.createElement("td");
                    labCell.textContent = medicamento.idLaboratorioNavigation.nombreLaboratorio

                    const activeCell = document.createElement("td");
                    activeCell.textContent = medicamento.activo == true ? "Activo" : "Inactivo";

                    const presentacionCell = document.createElement("td");
                    presentacionCell.textContent = medicamento.idPresentacionNavigation.nombrePresentacion

                    
                    const actionsCell = document.createElement("td");
                    actionsCell.classList.add("d-flex");

                    
                    const editButton = document.createElement("div");
                    editButton.classList.add("med-edit-button", "me-2", "cursor-pointer"); 
                    editButton.innerHTML = `
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square cursor-pointer" viewBox="0 0 16 16">
                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                            <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
                        </svg>
                    `;
                    editButton.addEventListener("click", () => goToEditMed(medicamento.idMedicamento));

                  
                    const deleteButton = document.createElement("div");
                    deleteButton.classList.add("med-delete-button");
                    deleteButton.innerHTML = `
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x-circle cursor-pointer" viewBox="0 0 16 16">
                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
                            <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708"/>
                        </svg>
                    `;
                    deleteButton.addEventListener("click", () => deleteMed(medicamento.idMedicamento));

                    
                    actionsCell.appendChild(editButton);
                    actionsCell.appendChild(deleteButton);

                    row.appendChild(nombreCell);
                    row.appendChild(descripcionCell)
                    row.appendChild(monodrogaCell);
                    row.appendChild(marcaCell);
                    row.appendChild(labCell)
                    row.appendChild(presentacionCell)
                    row.appendChild(precioCell);
                    row.appendChild(activeCell)
                    row.appendChild(actionsCell);

                    tableBody.appendChild(row);
                });
            })
            .catch(error => console.error("Error al obtener los datos:", error));
    }

    document.getElementById("searchMed").addEventListener("click", function() {
        const filtros = {
            IdLaboratorio: document.getElementById("laboratorios").value,
            IdMarca: document.getElementById("marcas").value,
            IdMonodroga: document.getElementById("monodrogas").value,
            IdPresentacion: document.getElementById("presentaciones").value,
            NombreComercial: document.getElementById("nombreComercial").value 
        };
    
        for (let key in filtros) {
            if (filtros[key] === "Seleccionar") {
                filtros[key] = 0;
            } 
        }
            
    
        fetch("https://localhost:44379/api/Medicamento/Filter", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(filtros)
        })
        .then(response => response.json())
        .then(data => {
            const tableBody = document.getElementById("tableBody");
            tableBody.innerHTML = "";
    
            data.forEach(medicamento => {
                const row = document.createElement("tr");
 
                const nombreCell = document.createElement("td");
                nombreCell.textContent = medicamento.nombreComercial;

                const precioCell = document.createElement("td");
                precioCell.textContent = `$${medicamento.precio.toFixed(2)}`;

                const monodrogaCell = document.createElement("td");
                monodrogaCell.textContent = medicamento.idMonodrogaNavigation.monodroga1;

                const marcaCell = document.createElement("td");
                marcaCell.textContent = medicamento.idMarcaNavigation.nombreMarca;

                const descripcionCell = document.createElement("td");
                descripcionCell.textContent = medicamento.descripcion

                const labCell = document.createElement("td");
                labCell.textContent = medicamento.idLaboratorioNavigation.nombreLaboratorio
                
                const activeCell = document.createElement("td");
                activeCell.textContent = medicamento.activo == true ? "Activo" : "Inactivo";
                const presentacionCell = document.createElement("td");
                presentacionCell.textContent = medicamento.idPresentacionNavigation.nombrePresentacion


                const actionsCell = document.createElement("td");
                actionsCell.classList.add("d-flex");

                
                const editButton = document.createElement("div");
                editButton.classList.add("med-edit-button", "me-2"); 
                editButton.innerHTML = `
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square cursor-pointer" viewBox="0 0 16 16">
                        <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                        <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
                    </svg>
                `;
                editButton.addEventListener("click", () => goToEditMed(medicamento.idMedicamento));

              
                const deleteButton = document.createElement("div");
                deleteButton.classList.add("med-delete-button");
                deleteButton.innerHTML = `
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x-circle" viewBox="0 0 16 16">
                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
                        <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708"/>
                    </svg>
                `;
                deleteButton.addEventListener("click", () => deleteMed(medicamento.idMedicamento));

                
                actionsCell.appendChild(editButton);
                actionsCell.appendChild(deleteButton);


                row.appendChild(nombreCell);
                row.appendChild(descripcionCell)

                row.appendChild(monodrogaCell);
                row.appendChild(marcaCell);
                row.appendChild(labCell)
                row.appendChild(presentacionCell)
                row.appendChild(precioCell);
                row.appendChild(activeCell);
                row.appendChild(actionsCell);
                
                tableBody.appendChild(row);
            });
        })
        .catch(error => console.error("Error al obtener los datos filtrados:", error));
    });

    document.getElementById("addMedBtn").addEventListener("click", function() {
        window.location.href = "./addMedicamentoForm.html";
    })


    loadMedicamentos();
});

function goToEditMed(id){
    localStorage.setItem("medicamentoId", id)

    window.location.href = "../../pages/Medicamentos/editMedicamentoForm.html"
}



document.addEventListener('DOMContentLoaded', () => {
  const status = localStorage.getItem('status');
  const event = localStorage.getItem('event');
  if (status && event) {
    if (status == "200") {
      ShowResult("Medicamento editado");
    } else {
      ShowResultError("Error al editar medicamento");
    }
    localStorage.removeItem('status');
    localStorage.removeItem('event');
  }else if(status){
    if (status == "200") {
        ShowResult("Medicamento agregado");
      } else {
        ShowResultError("Error al agregar medicamento");
      }
      localStorage.removeItem('status');
  }
});

