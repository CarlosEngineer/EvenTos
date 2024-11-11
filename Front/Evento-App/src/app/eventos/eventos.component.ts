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

  public eventos:any = [];
  public eventosFiltrados:any =[];
  largura: number = 150;
  margem: number =2;
  mostrarImagem: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(){
    return this._filtroLista;
  }

  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (      evento: { tema: string; local: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor)!== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor)!== -1 ||
      evento.tema.toLocaleLowerCase().indexOf(filtrarPor)!== -1
    );
  }


  public set filtroLista(value:string){
     this._filtroLista = value;
     this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;


  }

  alterarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }

  public GetEventos():void{ 
      this.http.get('https://localhost:5001/api/eventos').subscribe(
        response => {
          this.eventos = response;
          this.eventosFiltrados = this.eventos;
        },
        error => console.log(error)

      );


  }

}
