
const loadFoto = (filter) => {
    
    getFotos(filter)
    .then(res => {
    const fotos = res.data;
    renderFotos(fotos);
    })
}



const getFotos = name => axios.get("api/foto", name ? { params: { name } } : { });



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
                    
const initFilter = () => {
    const filter = document.querySelector("#fotos-filter input");
    filter.addEventListener("input", (e) => loadFoto(e.target.value));

}                   

function formSubmit(e) {
    e.preventDefault();
    const email = document.getElementById("user-email").value;
    const message = document.getElementById("user-message").value;

    console.log(email , message)

    axios.post("/api/userinfo", { email : email, message : message })
        .then(res => {
            console.log(res.data);
        }).catch(err => {
            console.error(err);
        });
}

       
