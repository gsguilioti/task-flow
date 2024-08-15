import axios from "axios";

class TimeTrackerService
{
    getById(id)
    {
        return axios.get(`http://localhost:5141/timeTracker/${id}`)
    }

    getAll()
    {
        return axios.get('http://localhost:5141/timeTracker')
    }

    getByTask(taskId)
    {
        return axios.get(`http://localhost:5141/timeTracker/task/${taskId}`)
    }

    create(timeTracker)
    {
        return axios.post('http://localhost:5141/timeTracker', timeTracker)
    }

    update(id, timeTracker)
    {
        return axios.put(`http://localhost:5141/timeTracker/${id}`, timeTracker)
    }

    delete(id)
    {
        return axios.delete(`http://localhost:5141/timeTracker/${id}`)
    }
}

export default new TimeTrackerService();