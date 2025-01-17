"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    var username = document.createElement("p");
    username.classList.add("fw-bold");
    username.textContent = user;
    var content = document.createElement("p");
    content.textContent = message;
    li.appendChild(username);
    li.appendChild(content);
    li.classList.add("list-group-item")
    document.getElementById("messagesList").appendChild(li);

    /*li.textContent = `${user} says ${message}`;*/
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});