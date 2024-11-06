import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent {

  constructor(private http: HttpClient){}

  ngOnInit():void{ //atribui o metodo geteventos
    this.GetEventos();
  }

  public eventos:any;

  public GetEventos():void{ //metodo criado para os dados
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => this.eventos = response,
      error => console.log(error)

    )
    

  }

}
