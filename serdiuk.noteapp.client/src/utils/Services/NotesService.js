import axios from "axios";
import {API_BASE_URL} from '../Constances'
import { getToken } from "./AuthService";

let instance ;

async function createInstance(){
    console.log(await getToken());
    instance = axios.create({
        baseURL: API_BASE_URL,
        headers: {
            'Authorization': await getToken(),  
        }, 
    })
}
createInstance();
export async function getAllUserNotes(page) {
    var data = await instance.get('', {
        params: {
            pageNumber: page,
        }
    })
        .then(response => response.data)
        .catch(e => console.error(e));

    return data;
}
export async function createNewNote(title, details) {

    var data = await instance.post('', JSON.stringify({title,details}))
        .then(response => response.data)
        .catch(e=>console.error(e))
            
    return data;
}