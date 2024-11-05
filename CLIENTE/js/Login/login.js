async function Loguear(){
    $username = document.getElementById("username").value;
    $password = document.getElementById("password").value;
    try{
        const response = await fetch("https://localhost:44379/api/PersonalEstablecimiento");
        const data = await response.json();
        data.forEach(item => {
            if($username == item.idPersonalNavigation.nroDoc && $password == item.idPersonalNavigation.psw){
                localStorage.setItem("nombrePersonal", `${item.idPersonalNavigation.nombre} ${item.idPersonalNavigation.apellido}`);
                localStorage.setItem("cargoPersonal", item.idCargoNavigation.cargo1);
                window.location.href = "../../index.html";
            }
        });
        alert("Credenciales incorrectas");
        LimpiarFormulario();
    } catch (error) {
        console.log("Error al cargar empleados", error);
    }
}

function LimpiarFormulario(){
    document.getElementById("loginForm").reset();
}

document.addEventListener("DOMContentLoaded",()=>{
    document.getElementById("loginBtn").addEventListener("click", Loguear);
})


