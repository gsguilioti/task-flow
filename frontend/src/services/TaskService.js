import axios from "axios";

class TaskService
{
    getById(id)
    {
        return axios.get(`http://localhost:5141/task/${id}`)
    }

    getAll() 
    {
        return axios.get('http://localhost:5141/task')
    }

    getByProject(projectId)
    {
        return axios.get(`http://localhost:5141/task/project/${projectId}`)
    }

    create(task)
    {
        return axios.post('http://localhost:5141/task', task)
    }

    update(id, task)
    {
        return axios.put(`http://localhost:5141/task/${id}`, task)
    }

    delete(id)
    {
        return axios.delete(`http://localhost:5141/task/${id}`)
    }
}

export default new TaskService();