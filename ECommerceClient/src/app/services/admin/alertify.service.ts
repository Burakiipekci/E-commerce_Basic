import { Injectable } from '@angular/core';
declare var alertify : any;
@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }

  message(message:string, messageType: MessageType, positon: Position){
   alertify.set('notifier','position',positon)
   
    alertify[messageType](message);

  }
}
export enum MessageType{
  Error = "Error",
  Message= "message",
  Notify = "Notify",
  Success= "success",
  Warning="warning"
}
export enum Position{
TopCenter="top-center",
TopRight="top-right",
TopLeft= " top-left",
BottomRight="bottom-right",
BottomCenter="bottom-center",
BottomLeft="bottom-left",
}