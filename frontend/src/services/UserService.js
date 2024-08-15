import axios from "axios";

class UserService
{
    getById(username)
    {
        return axios.get(`http://localhost:5141/user/${username}`)
    }

    getAll()
    {
        return axios.get('http://localhost:5141/user')
    }

    create(user)
    {
        return axios.post(`http://localhost:5141/register`, user)
    }

    login(user)
    {
        return axios.post(`http://localhost:5141/login`, login)
    }

    delete(username)
    {
        return axios.delete(`http://localhost:5141/user/${username}`)
    }
}

export default new UserService();