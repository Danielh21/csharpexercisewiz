const APIBase = 'http://localhost:50915/api/words'

async function fetchWords(parts) {
    if(parts.length < 3) {
        return
    }
    const dictonaryResponse = await fetch(`${APIBase}/db/${parts}`) 
    const webServiceResponse = await fetch(`${APIBase}/webservice/${parts}`)
    const dictonaryData = await dictonaryResponse.json();
    const webServiceData = await webServiceResponse.json();

    const displayDic =  dictonaryData.data.map( (word) => {
        return " " + word;
    })

    const displayWeb = webServiceData.data.map ( (word) => {
        return " " + word;
    })


    document.getElementById("DictonaryArea").innerText = displayDic.toString();
    document.getElementById("WebServiceArea").innerText = displayWeb.toString();
}

