import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";

@Injectable({
    providedIn: 'root'
})
export class SignalRService {
    public universeId;

    private _hubConnection: signalR.HubConnection

    public async startConnection() {
        this._hubConnection = new signalR.HubConnectionBuilder()
            .withUrl('http://localhost:5000/universe')
            .build();

        try {
            setTimeout(() => {
                this._hubConnection.start().then(() => {
                    console.log("Hub Connection Started");
                });
            }, 2000);

        }
        catch (e) {
            console.log(e);
        }
    }

    public onGetUniverseId() {
        this._hubConnection.on("ReceiveUniverseId", (id) => {
            console.log("Your Universe ID is: " + id);
        });
    }

    public async getUniverseId(): Promise<void> {
        try {
            await this._hubConnection.invoke('getUniverseId', "4");
        }
        catch (e) {
            console.log(e);
        }
    }
}