import {ShowResult, ShowResultError} from './toast.js';


document.addEventListener('DOMContentLoaded', () => {
  const status = localStorage.getItem('status');
  if (status) {
    if (status == "200") {
      ShowResult("Medicamento agregado");
    } else {
      ShowResultError("Error al agregar medicamento");
    }
    localStorage.removeItem('status');
  }
});