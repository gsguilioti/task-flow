import axios from "axios";

class ProjectService
{
    getById(id)
    {
        return axios.get(`http://localhost:5141/project/${id}`)
    }

    getAll()
    {
        return axios.get('http://localhost:5141/project')
    }

    create(project)
    {
        return axios.post('http://localhost:5141/project', project)
    }

    update(id, project)
    {
        return axios.put(`http://localhost:5141/project/${id}`, project)
    }

    async delete(id)
    {
        return await axios.delete(`http://localhost:5141/project/${id}`)
    }
}

export default new ProjectService();