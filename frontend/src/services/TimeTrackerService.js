import request from "../axios_config.js";

class TimeTrackerService
{
    getById(id)
    {
        return request.get(`http://localhost:5141/timeTracker/${id}`)
    }

    getAll()
    {
        return request.get('http://localhost:5141/timeTracker')
    }

    getByTask(taskId)
    {
        return request.get(`http://localhost:5141/timeTracker/task/${taskId}`)
    }

    create(timeTracker)
    {
        return request.post('http://localhost:5141/timeTracker', timeTracker)
    }

    update(id, timeTracker)
    {
        return request.put(`http://localhost:5141/timeTracker/${id}`, timeTracker)
    }

    delete(id)
    {
        return request.delete(`http://localhost:5141/timeTracker/${id}`)
    }
}

export default new TimeTrackerService();