import request from "../axios_config.js";

class TaskService
{
    getById(id)
    {
        return request.get(`http://localhost:5141/task/${id}`)
    }

    getAll() 
    {
        return request.get('http://localhost:5141/task')
    }

    getByProject(projectId)
    {
        return request.get(`http://localhost:5141/task/project/${projectId}`)
    }

    create(task)
    {
        return request.post('http://localhost:5141/task', task)
    }

    update(id, task)
    {
        return request.put(`http://localhost:5141/task/${id}`, task)
    }

    delete(id)
    {
        return request.delete(`http://localhost:5141/task/${id}`)
    }
}

export default new TaskService();