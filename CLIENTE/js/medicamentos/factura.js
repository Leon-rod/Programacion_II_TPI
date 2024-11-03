let idFactura;
async function ObtenerUltimoId(){
    try{
        const $detalleIdFactura = document.getElementById("detalleIdFactura");
        const response = await fetch("https://localhost:44379/api/Factura/GetLastId");
        const data = await response.json();
        document.getElementById("facturaId").value = data + 1;
        idFactura = data + 1;
        $detalleIdFactura.value = data + 1;
    } catch (error) {
        console.log("Error al cargar el id", error);
    }
}
async function CargarClientes(){
    try{
        const $clientSelect = document.getElementById("cliente");
        const response = await fetch("https://localhost:44379/api/Cliente");
        const data = await response.json();
        // $clientSelect.innerHTML = '';
        data.forEach(item => {
            const option = document.createElement("option");
            option.value = item.idCliente; 
            option.textContent = `${item.apellido} ${item.nombre}`; 
            $clientSelect.appendChild(option);
        });
    } catch (error) {
        console.log("Error al cargar clientes", error);
    }
}
async function CargarEmpleados(){
    try{
        const $employeeSelect = document.getElementById("empleado");
        const response = await fetch("https://localhost:44379/api/PersonalEstablecimiento");
        const data = await response.json();
        data.forEach(item => {
            const option = document.createElement("option");
            option.value = item.idPersonalCargosEstablecimientos; 
            option.textContent = `${item.idPersonalNavigation.apellido} ${item.idPersonalNavigation.nombre} - ${item.idEstablecimientoNavigation.nombre}`; 
            $employeeSelect.appendChild(option);
        });
    } catch (error) {
        console.log("Error al cargar empleados", error);
    }
}
async function CargarCoberturas(){
    try{
        const $detailCoberture = document.getElementById("detalleCobertura");
        const response = await fetch("https://localhost:44379/api/Cobertura");
        const data = await response.json();
        // $detailCoberture.innerHTML = '';
        data.forEach(item => {
            const option = document.createElement("option");
            option.value = item.idTipoCobertura; 
            option.textContent = item.descripcion; 
            $detailCoberture.appendChild(option);
        });
    } catch (error) {
        console.log("Error al cargar coberturas", error);
    }
}

async function CargarMedicamentos(){
    try{
        const $detailMedicine = document.getElementById("detalleMedicamento");
        const idPersonalEstablecimientos = document.getElementById("empleado").value;
        $detailMedicine.innerHTML = '';
        let idEstablecimiento;
        const responsePersonalEstablecimiento = await fetch("https://localhost:44379/api/PersonalEstablecimiento/ID?id=" + idPersonalEstablecimientos);
        const dataPersonalEstablecimiento = await responsePersonalEstablecimiento.json();
        idEstablecimiento = dataPersonalEstablecimiento.idEstablecimiento;
        const responseEstablishment = await fetch("https://localhost:44379/Establishment?id=" + idEstablecimiento);
        const dataEstablishment = await responseEstablishment.json();
        dataEstablishment.forEach(item => {
            if (item.idMedicamentoLoteNavigation != null){
                const option = document.createElement("option");
                option.value = item.idMedicamentoLote; 
                option.textContent = item.idMedicamentoLoteNavigation.idMedicamentoNavigation.nombreComercial; 
                $detailMedicine.appendChild(option);
            }
        });
    } catch (error) {
        console.log("Error al cargar medicamentos", error);
    }
}
document.addEventListener("DOMContentLoaded", () => {
    ObtenerUltimoId();
    CargarClientes();
    CargarEmpleados();
    CargarCoberturas();

    document.getElementById("empleado").addEventListener("change", CargarMedicamentos);
})



let dispensaciones = [];
let idDetalleFactura = 1;
document.getElementById("detalleId").value = idDetalleFactura;
function agregarDetalle() {
   idDetalleFactura++;
   // Obtener valores de los campos de detalle
   const idFactura = document.getElementById('detalleIdFactura').value;
   const idDispensacion = document.getElementById('detalleId').value;
   const idMedicamentoLote = document.getElementById('detalleMedicamento').value;
   const idCobertura = document.getElementById('detalleCobertura').value;
   const descuento = document.getElementById('detalleDescuento').value;
   const precioUnitario = document.getElementById('detallePrecio').value;
   const cantidad = document.getElementById('detalleCantidad').value;
   const matricula = document.getElementById('detalleMatricula').value;
   const codigoValidacion = document.getElementById('detalleCodigo').value;
   
   dispensaciones.push({
    idFactura,
    idDispensacion,
    idMedicamentoLote,
    idCobertura,
    descuento,
    precioUnitario,
    cantidad,
    matricula,
    codigoValidacion
   });
   actualizarTablaDetalles();
   document.getElementById("detalleForm").reset();
   document.getElementById("detalleId").value = idDetalleFactura;
   document.getElementById("detalleIdFactura").value = idFactura;
}

function actualizarTablaDetalles() {
    const table = document.getElementById('detallesTable').getElementsByTagName('tbody')[0];
    table.innerHTML = '';
    dispensaciones.forEach((detalle, index) => {
        const row = table.insertRow();
        row.innerHTML = `
            <td>${detalle.idFactura}</td>
            <td>${index + 1}</td>
            <td>${detalle.idMedicamentoLote}</td>
            <td>${detalle.idCobertura}</td>
            <td>${detalle.descuento}</td>
            <td>${detalle.precioUnitario}</td>
            <td>${detalle.cantidad}</td>
            <td>${detalle.matricula}</td>
            <td>${detalle.codigoValidacion}</td>
            <td><button type="button" class="btn btn-danger btn-sm" onclick="eliminarDetalle(${index})" id="deleteBtn">Eliminar</button></td>
        `;
    });
}

function eliminarDetalle(index) {
    dispensaciones.splice(index, 1);
    dispensaciones.forEach((detalle, i) => detalle.idDetallePedido = i );
    actualizarTablaDetalles();
}

async function realizarFactura() {
    const facturaData = {
        idFactura: document.getElementById("facturaId").value,
        idCliente: document.getElementById("cliente").value,
        idPersonalCargosEstablecimientos: document.getElementById("empleado").value,
        fecha: document.getElementById("fecha").value
    };

    const facturaResponse = await fetch("https://localhost:44379/api/Factura", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(facturaData)
    });

    if (facturaResponse.ok) {
        // await Promise.all(detalles.map(detalle => {
        //     return fetch("https://localhost:44379/api/DetallePedido", {
        //         method: "POST",
        //         headers: { "Content-Type": "application/json" },
        //         body: JSON.stringify({
        //             idPedido: detalle.idPedido,
        //             idDetallePedido: detalle.idDetallePedido,
        //             idMedicamento: detalle.idMedicamento,
        //             idProveedor: detalle.idProveedor,
        //             precioUnitario: detalle.precioUnitario,
        //             cantidad: detalle.cantidad
        //         })
        //     });
        // }));
        for(var detalle of dispensaciones) {
            const detalleResponse = await fetch("https://localhost:44379/api/Dispensacion", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    idFactura: detalle.idFactura,
                    idDispensacion: detalle.idDispensacion,
                    idMedicamentoLote: detalle.idMedicamentoLote,
                    idCobertura: detalle.idCobertura,
                    descuento: detalle.descuento,
                    precioUnitario: detalle.precioUnitario,
                    cantidad: detalle.cantidad,
                    matricula: detalle.matricula,
                    codigoValidacion: detalle.codigoValidacion
                })
            });

            if (!detalleResponse.ok) {
                alert("Error al enviar una dispensacion.");
            }
        }

        // // Mostrar el toast
        // const toastElement = document.getElementById("pedidoToast");
        // const toast = new bootstrap.Toast(toastElement);
        // toast.show();

        // Limpiar el formulario de pedido
        document.getElementById("empleado").value = "";
        document.getElementById("cliente").value = "";
        document.getElementById("fecha").value = "";

        // Limpiar la tabla de detalles y resetear el contador de detalles
        detalles = [];
        idDetalleCounter = 1;
        actualizarTablaDetalles();
        
        // Recargar el ID del pedido
        ObtenerUltimoId();

    } else {
        alert("Error al enviar el pedido.");
    }
}