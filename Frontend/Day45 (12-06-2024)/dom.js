const accessingParaElement=()=>{
    let para=document.getElementById('para1')
    console.log(para+"hii")
}

const dateDisplay=()=>{
    document.getElementById('para2').innerHTML=Date()
}

const nodeList=document.getElementsByName('gen')
console.log(nodeList)

const tagList=document.getElementsByTagName('P')
console.log(tagList)

const classList=document.getElementsByClassName('demo')
console.log(classList)

const paraId=document.querySelector('.para1')
console.log(paraId)

// adding element ot existing element
let existingDiv=document.getElementById('divId')
let element=document.createElement('div')
element.innerHTML='<h4>hey we are still learning</h4>'
existingDiv.appendChild(element)


//removing the element

const removeElement=()=>{
    let existingDivWithId=document.getElementById('divId')
    document.body.removeChild(existingDivWithId)
}


