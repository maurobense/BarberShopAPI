async function getBarbersFromBarberShop(idBarber) {
    try {
        let response = await fetch(`https://localhost:44307/api/Barbers?idBarberShop=${idBarber}`)
        let responseJson = await response.json();
        let data = JSON.parse(responseJson);
        console.log(data);
    } catch (e) {
        console.log(e);
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
