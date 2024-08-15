import axios from "axios";

class CollaboratorService
{
    getById(id)
    {
        return axios.get(`http://localhost:5141/collaborator/${id}`)
    }

    getAll()
    {
        return axios.get('http://localhost:5141/collaborator')
    }

    create(collaborator)
    {
        return axios.post('http://localhost:5141/collaborator', collaborator)
    }

    update(id, collaborator)
    {
        return axios.put(`http://localhost:5141/collaborator/${id}`, collaborator)
    }

    delete(id)
    {
        return axios.delete(`http://localhost:5141/collaborator/${id}`)
    }
}

export default new CollaboratorService();