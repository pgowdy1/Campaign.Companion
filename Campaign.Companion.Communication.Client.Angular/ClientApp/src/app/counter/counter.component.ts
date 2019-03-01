import { Component } from '@angular/core';
import { SignalRService } from '../signalr/signalr.service';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {

  constructor(private _signalRService: SignalRService) {}

  public universeId = 0;

  public async getUniverseId(): Promise<void> {
    this._signalRService.getUniverseId();
  }
}
