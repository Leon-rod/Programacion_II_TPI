import {ShowResult} from './toast.js';


document.addEventListener('DOMContentLoaded', () => {
  const status = localStorage.getItem('status');
  if (status) {
    if (status == "200") {
      ShowResult("Confirmado");
    } else {
      ShowResult("Cancelado");
    }
    localStorage.removeItem('status');
  }
});