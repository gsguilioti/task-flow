import request from "../axios_config.js";

class ProjectService
{
    getById(id)
    {
        return request.get(`http://localhost:5141/project/${id}`)
    }

    getAll()
    {
        return request.get('http://localhost:5141/project')
    }

    create(project)
    {
        return request.post('http://localhost:5141/project', project)
    }

    update(id, project)
    {
        return request.put(`http://localhost:5141/project/${id}`, project)
    }

    async delete(id)
    {
        return await request.delete(`http://localhost:5141/project/${id}`)
    }
}

export default new ProjectService();