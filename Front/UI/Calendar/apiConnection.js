async function getBarbersFromBarberShop(idBarber) {
    try {
        let url = `https://localhost:44307/api/Barbers?idBarberShop=${idBarber}`;
        const param = {
            method: 'Get',
            headers: {"Authorization" : `Bearer 2:e22d3a46-b60d-4ed8-b310-2014ded4113e` }
        }
        const sendRequest = await fetch(url, param)
        if(!sendRequest.ok){ throw sendRequest}
        const response = await sendRequest.json()
        console.log(JSON.parse(response));
    }catch(e){
        let res = await e.json();
        console.log(res.Message);
    }

}

async function loadTurn(dateFrom, dateTo, idBarber) {
    const url = `https://localhost:44307/api/Turn?dateFrom=${dateFrom}&dateTo=${dateTo}&idBarber=${idBarber}`
    const param = {
        method: 'Post',
        headers: {
            "content-type": "application/json;charset = UTF-8"
        },
    }
    const sendRequest = await fetch(url, param)
    const response = await sendRequest.json()
    console.log(response);
}

async function getTurnsByDayAndBarber(idBarber,day) {
    try {
        let response = await fetch(`https://localhost:44307/api/Turn?idBarber=${idBarber}&day=${day}`)
        let responseJson = await response.json();
        let data = JSON.parse(responseJson);
        console.log(data);
    } catch (e) {
        console.log(e);
    }
}
