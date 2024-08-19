import request from "../axios_config.js";

class UserService
{
    getById(username)
    {
        return request.get(`http://localhost:5141/user/${username}`)
    }

    getAll()
    {
        return request.get('http://localhost:5141/user')
    }

    login(user)
    {
        return request.post(`http://localhost:5141/user/login`, user)
    }

    delete(username)
    {
        return request.delete(`http://localhost:5141/user/${username}`)
    }
}

export default new UserService();