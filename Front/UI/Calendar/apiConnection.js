async function getBarbersFromBarberShop(idBarber){
    try{
    let response = await fetch(`https://localhost:44307/api/Barbers?idBarberShop=${idBarber}`)
    let responseJson = await response.json();
    let data = JSON.parse(responseJson);
    console.log(data);
    }catch(e){
        console.log(e);
    }
}