const StrongPassword = async () => {
    try {
        const password = document.querySelector("#password").value
        const response = await fetch('api/StrongPassword', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)
        })
        if (response.ok) {
            const strongPass = document.querySelector("#strongPass")
            const res = await response.json()
            strongPass.value = res.score
            return res.score
        }            
        else
            throw ("error")
    }
    catch (e) {
        alert(e)
    }
}

const SignIn = async () => {
    try {
        const user = {
            id: 0,
            email: document.querySelector("#email").value,
            password: document.querySelector("#password").value,
            firstName: document.querySelector("#firstName").value,
            lastName: document.querySelector("#lastName").value,
        }
        const strongPass = await StrongPassword()
        if (strongPass < 3)
            throw ("הסיסמה לא חזקה!")
        const response = await fetch('api/Users', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        })
        if (response.ok) {
            const dataRenspose = await response.json()
            alert(`שלום ${dataRenspose.firstName} , נרשמת בהצלחה, הינך משתמש מס' ${dataRenspose.id}`)
        }
        else if (response.status == 400) {
            throw ("הסיסמה לא מספיק חזקה")
        }
        else
            throw("ההרשמה לא הצליחה, נסה שוב")
    }
    catch (e) {
        alert(e)
    }
}

const LogIn = async () => {
    try {
        const enter = {
            email: document.querySelector("#login_email").value,
            password: document.querySelector("#login_password").value,
        }
        const post = await fetch('api/Users/LogIn', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(enter)
        })
        if (post.ok) {
            const dataPost = await post.json()
            sessionStorage.setItem('CurrentUser', JSON.stringify(dataPost))
            window.location.href = "login.html"
            alert(`שלום ${dataPost.firstName} ברוך שובך`)
        }
        else
            throw("המשתמש לא קיים, נסה שוב")
    }
    catch (e)
    {
        alert(e)
    }
}