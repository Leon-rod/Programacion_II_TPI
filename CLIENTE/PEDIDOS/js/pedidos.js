async function cargarPedidos() {
    try {
        const response = await fetch('https://localhost:44379/api/Pedido');
        const pedidos = await response.json();
        const pedidosTableBody = document.getElementById('pedidosTable').getElementsByTagName('tbody')[0];

        pedidos.forEach(pedido => {
            const row = pedidosTableBody.insertRow();
            row.insertCell(0).textContent = pedido.idPedido;
            row.insertCell(1).textContent = `${pedido.idPersonalCargosEstablecimientosNavigation.idPersonalNavigation.nombre} ${pedido.idPersonalCargosEstablecimientosNavigation.idPersonalNavigation.apellido} (${pedido.idPersonalCargosEstablecimientosNavigation.idEstablecimientoNavigation.nombre})`;
            row.insertCell(2).textContent = pedido.idLogisticaNavigation.nombreEmpresa;
            row.insertCell(3).textContent = new Date(pedido.fecha).toLocaleDateString();
            

            const verDetallesBtn = document.createElement('button');
            verDetallesBtn.classList.add('btn', 'btn-info');
            verDetallesBtn.textContent = 'Ver Detalles';
            verDetallesBtn.onclick = () => cargarDetallesPedido(pedido.idPedido);
            row.insertCell(4).appendChild(verDetallesBtn);
        });
    } catch (error) {
        console.error("Error cargando pedidos:", error);
        
    }
}

async function cargarDetallesPedido(idPedido) {
    try {
        const response = await fetch(`https://localhost:44379/api/DetallePedido?id=${idPedido}`);
        const detalles = await response.json();
        
        const detallesTableBody = document.getElementById('detallesPedidoTable').getElementsByTagName('tbody')[0];
        detallesTableBody.innerHTML = '';

        detalles.forEach(detalle => {
            const row = detallesTableBody.insertRow();
            row.insertCell(0).textContent = detalle.idMedicamentoLoteNavigation
            ? `${detalle.idMedicamentoLoteNavigation.idMedicamentoNavigation.nombreComercial} (${detalle.idMedicamentoLoteNavigation.lote})`
            : detalle.idProductoNavigation.nombre;

            row.insertCell(1).textContent = detalle.idProveedorNavigation.razonSocial 
            row.insertCell(2).textContent = "$" + detalle.precioUnitario; 
            row.insertCell(3).textContent = detalle.cantidad; 
        });

        
        const modal = new bootstrap.Modal(document.getElementById('detalleModal'), {
            backdrop: 'static',
            keyboard: false
        });
        modal.show();
    } catch (error) {
        console.error("Error cargando detalles del pedido:", error);
        
    }
}



document.addEventListener('DOMContentLoaded', () => {
    cargarPedidos();
});
