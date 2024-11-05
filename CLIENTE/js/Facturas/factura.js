async function cargarFacturas() {
    try {
        const response = await fetch('https://localhost:44379/api/Factura');
        const facturas = await response.json();
        const facturasTableBody = document.getElementById('facturasTable').getElementsByTagName('tbody')[0];

        facturas.forEach(factura => {
            const row = facturasTableBody.insertRow();
            row.insertCell(0).textContent = factura.idFactura;
            row.insertCell(1).textContent = `${factura.idPersonalCargosEstablecimientosNavigation.idPersonalNavigation.nombre} ${factura.idPersonalCargosEstablecimientosNavigation.idPersonalNavigation.apellido} (${factura.idPersonalCargosEstablecimientosNavigation.idEstablecimientoNavigation.nombre})`;
            row.insertCell(2).textContent = `${factura.idClienteNavigation.nombre} ${factura.idClienteNavigation.apellido}`;
            row.insertCell(3).textContent = new Date(factura.fecha).toLocaleDateString();
            

            const verDetallesBtn = document.createElement('button');
            verDetallesBtn.classList.add('btn', 'btn-info');
            verDetallesBtn.textContent = 'Ver Dispensaciones';
            verDetallesBtn.onclick = () => cargarDispensacionesFacturas(factura.idFactura);
            row.insertCell(4).appendChild(verDetallesBtn);
        });
    } catch (error) {
        console.error("Error cargando facturas:", error);
        
    }
}

async function cargarDispensacionesFacturas(idFactura) {
    try {
        const response = await fetch(`https://localhost:44379/api/Dispensacion/Factura?id=${idFactura}`);
        const dispensaciones = await response.json();
        
        const dispensacionesTableBody = document.getElementById('dispensacionesFacturaTable').getElementsByTagName('tbody')[0];
        dispensacionesTableBody.innerHTML = '';

        dispensaciones.forEach(dispensacion => {
            const row = dispensacionesTableBody.insertRow();
            row.insertCell(0).textContent = dispensacion.idProducto ? dispensacion.idProductoNavigation.nombre : "-";
            row.insertCell(1).textContent = dispensacion.idProducto ? dispensacion.idProductoNavigation.idMarcaNavigation.nombreMarca : "-";
            row.insertCell(2).textContent = dispensacion.idMedicamentoLote ? `${dispensacion.idMedicamentoLoteNavigation.idMedicamentoNavigation.nombreComercial} (${dispensacion.idMedicamentoLoteNavigation.lote})`
            : "-";
            row.insertCell(3).textContent = dispensacion.idMedicamentoLote ?  dispensacion.idCoberturaNavigation.descripcion : "-";
            row.insertCell(4).textContent = "$" + dispensacion.precioUnitario; 
            row.insertCell(5).textContent = dispensacion.cantidad; 
            row.insertCell(6).textContent = dispensacion.idMedicamentoLote ? dispensacion.descuento * 100 + '%' : "0%"; 
            row.insertCell(7).textContent = dispensacion.idMedicamentoLote ? dispensacion.matricula : "-"; 
            row.insertCell(8).textContent = dispensacion.idMedicamentoLote ? dispensacion.codigoValidacion : "-"; 
        });

        
        const modal = new bootstrap.Modal(document.getElementById('dispensacionModal'), {
            backdrop: 'static',
            keyboard: false
        });
        modal.show();
    } catch (error) {
        console.error("Error cargando dispensaciones de la factura:", error);
        
    }
}



document.addEventListener('DOMContentLoaded', () => {
    cargarFacturas();
});
