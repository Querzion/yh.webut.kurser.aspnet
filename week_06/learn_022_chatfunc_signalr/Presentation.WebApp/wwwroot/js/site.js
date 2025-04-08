const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build()

connection.on("ReceiveMessage", (username, message) => {
    const div = document.createElement('div')
    div.innerHTML =
        `
        <div class="item">
            <div class="name">${username}</div>
            <div class="chat-message">${message}</div>
        </div>
        `
    document.getElementById("chat-messages").appendChild(div)
})

connection.start().catch(error => console.error(error.toString()))

function sendMessage() {
    const username = document.getElementById("username").value
    const message = document.getElementById("message").value
    
    connection.invoke("SendMessage", username, message).catch(error => console.error(error.toString()))
    document.getElementById("message").value = ''
}