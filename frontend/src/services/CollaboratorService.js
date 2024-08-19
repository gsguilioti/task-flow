import request from "../axios_config.js";

class CollaboratorService
{
    getById(id)
    {
        return request.get(`http://localhost:5141/collaborator/${id}`)
    }

    getAll()
    {
        return request.get('http://localhost:5141/collaborator')
    }

    create(collaborator)
    {
        return request.post('http://localhost:5141/collaborator', collaborator)
    }

    update(id, collaborator)
    {
        return request.put(`http://localhost:5141/collaborator/${id}`, collaborator)
    }

    delete(id)
    {
        return request.delete(`http://localhost:5141/collaborator/${id}`)
    }
}

export default new CollaboratorService();