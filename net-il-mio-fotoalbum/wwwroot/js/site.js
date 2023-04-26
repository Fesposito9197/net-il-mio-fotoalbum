const getFotos = () => axios.get("api/foto")


const renderFotos = fotos => {
    const fotosBody = document.querySelector("#ms-fotos");
    fotosBody.innerHTML = fotos.map(fotoComponent).join("")
}

const fotoComponent = foto =>
    ` 
    <tr>
        <td>${foto.id}</td>
        <td class="fw-bold">
            <a class="text-decoration-none text-black" >${foto.title}</a>
        </td>
        <td class="fw-bold">${foto.description}</td>
        <td class=" fw-bold">
         <a href = "/Home/detail/${foto.id}" class="btn btn-success" > Dettagli </a>
        </td>

    </tr>
`;
                    
                    
                    
        

       
