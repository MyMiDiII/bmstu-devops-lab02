import UserInterface from "./Interfaces/UserInterface";

interface User {
    id: Number,
    login: String,
    role: String
}

export default {
    async login(login: String, password: String) {
        const result = await UserInterface.login(login, password);
        
        console.log("LoginAuth:", result.status);

        if (result.status == 200) {
            console.log(result.data);
            localStorage.setItem('currentUser', JSON.stringify(result.data));
            return true;
        }

        return false
    },

    async register(login: String, password: String) {
        const result = await UserInterface.register(login, password);
        
        if (result.status == 200) {
            return true;
        }

        return false;
    },
    
    getCurrentUser() {
        return JSON.parse(String(localStorage.getItem("currentUser")));
    },
    
    logout() {
        const user: User = {
            id: 0,
            login: "guest",
            role: "guest"
        }
    
        localStorage.setItem('currentUser', JSON.stringify(user));
    }
}
