import axios from "axios";

const API = "http://localhost:5110/api/team"




export async function getAllTeams(token) {
    try {
        const response = await axios.get(API,
            {
                validateStatus: status => status === 200,
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }
        );

        return response.data;
    } 
    catch (error) {
        console.error(error)
    }
}


export async function createTeam(team, token) {
    try {
        const response = await axios.post(API, team,
            {
                validateStatus: status => status === 200,
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }
        );

        return response.data;
    } 
    catch (error) {
        console.error(error)
    }
}


export async function getTeamById(id, token) {
    try {
        const response = await axios.post(API.concat('/', id),
            {
                validateStatus: status => status === 200,
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }
        );

        return response.data;
    } 
    catch (error) {
        console.error(error)
    }
}


export async function UpdateTeamById(id, team, token) {
    try {
        const response = await axios.put(API.concat('/', id), team,
            {
                validateStatus: status => status === 200,
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }
        );

        return response.data;
    } 
    catch (error) {
        console.error(error)
    }
}


export async function deleteTeamById(id, token) {
    try {
        const response = await axios.delete(API.concat('/', id),
            {
                validateStatus: status => status === 200,
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }
        );

        return response.data;
    } 
    catch (error) {
        console.error(error)
    }
}


