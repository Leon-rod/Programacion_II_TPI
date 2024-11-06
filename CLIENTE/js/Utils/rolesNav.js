function CargarNav(){
    const rol = localStorage.getItem("cargoPersonal");
    const $navBar = document.getElementById("container__navBar");
    $navBar.innerHTML = '';

    if(rol === "Asistente Administrativo"){
        const li = document.createElement("li");
        li.innerHTML = `<li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Soporte</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Medicamentos/medicamentos.html">Medicamentos</a></li>
                            </ul>
                        </li>`;
        $navBar.appendChild(li);
    }

    if(rol === "Director tecnico"){
        const li = document.createElement("li");
        li.innerHTML = `<li class="nav-item"><a class="nav-link active" aria-current="page" href="#">Inicio</a></li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Facturas</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Factura/factura.html">Ver facturas</a></li>
                                <li><a class="dropdown-item" href="../Factura/cargarFactura.html">Crear factura</a></li>
                            </ul>
                        </li>

                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Pedidos</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Pedidos/pedidos.html">Ver pedidos</a></li>
                                <li><a class="dropdown-item" href="../Pedidos/cargarPedido.html">Crear pedido</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Soporte</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Medicamentos/medicamentos.html">Medicamentos</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Dashboard</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="#">Reporte 1</a></li>
                                <li><a class="dropdown-item" href="#">Reporte 2</a></li>
                            </ul>
                        </li>`;
        $navBar.appendChild(li);
    }
    if (rol === "Analista de Mercado Farmaceutico"){

        const li = document.createElement("li");
        li.innerHTML = `<li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Dashboard</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="#">Reporte 1</a></li>
                                <li><a class="dropdown-item" href="#">Reporte 2</a></li>
                            </ul>
                        </li>`;
        $navBar.appendChild(li);

    }
}
document.addEventListener("DOMContentLoaded", CargarNav)