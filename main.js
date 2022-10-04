const form = document.getElementById('form');
const nombre = document.getElementById('nombre');
const apellido = document.getElementById('apellido');
const edad = document.getElementById('edad');
const empresa = document.getElementById('empresa');
var hombre = document.getElementById('hombre');
var mujer = document.getElementById('mujer');
var otro = document.getElementById('otro');

form.addEventListener('submit', e=>{
    e.preventDefault();
    
});


function checkInputs()
{
    const nombreValue = nombre.value.trim();
    const apellidoValue = apellido.value.trim();
    const edadValue = edad.value.trim();
    const empresaValue = empresa.value.trim();

    if(nombreValue === '')
    {
        getMensajeError(nombre, 'El campo usuario no puede quedar en blanco');
    }
    else
    {
       getValidacion(nombre);
    }
    if(apellidoValue === '')
    {
        getMensajeError(apellido, 'El campo apellido no puede quedar en blanco')
    }
    else
    {
        getValidacion(apellido);
    }
    if(edadValue === '')
    {
        getMensajeError(edad, 'El campo edad no puede quedar en blanco')
    }else
    {
        getValidacion(edad);
    }
    if(empresaValue === '')
    {
        getMensajeError(empresa,'El campo empresa no puede quedar en blanco');
    }else{
        getValidacion(empresa);
    }
    if(hombre.checked === true || mujer.checked === true || otro.checked === true)
    {
        getValidacionRadio(otro);
    }else
    {
        getMensajeErrorRadio(otro, 'Debe seleccionar un género obligatoriamente');
    }
    
    
}
function clearText()
{
document.getElementById('form').value='';
document.getElementById('nombre').value = '';
document.getElementById('apellido').value = '';
document.getElementById('edad').value = '';
document.getElementById('empresa').value = '';
document.getElementById('hombre').checked = false;
document.getElementById('mujer').checked = false;
document.getElementById('otro').checked = false;

}
function getMensajeError(input, mensaje)
{
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.innerText = mensaje;
    formControl.className = 'form-control error';
}  
function getValidacion(input) {
	const formControl = input.parentElement;
	formControl.className = 'form-control validated';
}
function getMensajeErrorRadio(input, mensaje)
{
    const formControl = input.parentElement;
    const small = formControl.querySelector('small');
    small.innerText = mensaje;
    formControl.className = 'form-controlradio error';
}  
function getValidacionRadio(input) {
	const formControl = input.parentElement;
	formControl.className = 'form-controlradio validated';
}
