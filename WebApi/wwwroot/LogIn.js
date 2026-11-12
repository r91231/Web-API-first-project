const CurrentUser = JSON.parse(sessionStorage.getItem('CurrentUser'))
const p = document.querySelector("#welcome")
p.textContent = `Hello ${CurrentUser.firstName},you have successfuly logged in`
const update_email = document.querySelector("#update_email")
const update_password = document.querySelector("#update_password")
const update_firstName = document.querySelector("#update_firstName")
const update_lastName = document.querySelector("#update_lastName")
update_email.value = CurrentUser.email
update_password.value = CurrentUser.password
update_firstName.value = CurrentUser.firstName
update_lastName.value = CurrentUser.lastName
const DisplayDitails = async () => {
    const ditails = document.querySelector(".updateDetails")
    ditails.style.display = "block"
}
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
        }
        else
            throw ("error")
    }
    catch (e) {
        alert(e)
    }
}

const UpdateDetails = async () => {
    const updateUserDetails = {
        id: CurrentUser.id,
        email: update_email.value,
        password: update_password.value,
        firstName: update_firstName.value,
        lastName: update_lastName.value,
    }
    try {
        const strongPass = await StrongPassword()
        if (strongPass < 3)
            throw ("הסיסמה לא חזקה!")

        const response = await fetch(`api/Users/${updateUserDetails.id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(updateUserDetails)
        })
        if (response.ok) {
            sessionStorage.setItem('CurrentUser', JSON.stringify(updateUserDetails))
            alert("the details successfuly updated")
        }
        else if (response.status == 400) {
            throw ("הסיסמה לא חזקה")
        }
        else {
            throw ("error on the update")
        }
    }
    catch (e) {
        alert(e)
    }
}
