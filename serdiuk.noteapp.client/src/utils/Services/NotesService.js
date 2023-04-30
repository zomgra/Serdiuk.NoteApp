import axios from "axios";
import { API_BASE_URL } from '../Constances'
import { getToken } from "./AuthService";

let instance;

async function createInstance() {
    instance = axios.create({
        baseURL: API_BASE_URL,
        headers: {
            'Authorization': await getToken(),
        },
    })
}
createInstance();

export async function getNoteById(id) {
    var data = await instance.get(`/${id}`)
    .then(response=>response.data)
    .catch(e=>console.error(e));

    return data;
}

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

    var request = { title, details };
    var data = await instance.post('', request)
        .then(response => response.data)
        .catch(e => console.error(e))

    return data;
}

export async function editNoteHandler(id, title, details) {
    var request = {id, title,details};

    var data = await instance.put('', request)
        .then(response => response.data)
        .catch(e => console.error(e))

    return data;
}

export async function deleteNoteHandler(id) {

    var data = await instance.delete('', {
        params:{
            id:id
        }
    })
    .then(response=>response.data)
    .catch(e=>console.error(e));

    return data;
}