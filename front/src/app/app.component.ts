import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Usuario } from './model/usuario.model';
import { UserService } from './service/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { debug } from 'util';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  usuario: Usuario;
  idUser: string;
  unSubscribe;
  title = 'avivatec-test';
  form: FormGroup;
  users: Array<Usuario> = [];
  dataSource;
  isUpdate: boolean;

  displayedColumns: string[] = ['nome', 'email', 'login', 'editar','excluir'];

  constructor (
    private userService: UserService,
    private _snackBar: MatSnackBar
  ){
    this.form = new FormGroup({
      nome: new FormControl('',Validators.required),
      email: new FormControl('',[Validators.email,Validators.required]),
      login: new FormControl('',Validators.required),
      senha: new FormControl('',Validators.required)
    });
  }


  msgSucesso(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }



  ngOnInit(): void {
    this.listaUsuarios();
  }

  onSubmit() {
    this.usuario = new Usuario();
    this.usuario.nome  = this.form.controls.nome.value;
    this.usuario.email = this.form.controls.email.value;
    this.usuario.login = this.form.controls.login.value;
    this.usuario.senha = this.form.controls.senha.value;


    if(!this.isUpdate){
      this.unSubscribe = this.userService.createUser(this.usuario).subscribe(
        response => {
            this.msgSucesso("Usuario Incluido com sucesso", "Fechar")
        },
        err => {
          console.log(err);
        },
        () => {
          this.listaUsuarios();
        })
    }else{
      this.usuario.Id = this.idUser;

      this.unSubscribe = this.userService.updateUser(this.usuario).subscribe(
        response => {
            this.msgSucesso("Usuario atualizado com sucesso", "Fechar")
        },
        err => {
          console.log(err);
        },
        () => {
          this.isUpdate = false;
          this.listaUsuarios();
        })
    }
  }

  listaUsuarios(){
    this.form.reset();
    this.users = [];

    this.unSubscribe = this.userService.getUser().subscribe(
      response => {
        response.forEach(element => {
          this.users.push({
            Id: element.id,
            nome: element.nome,
            email: element.email,
            login: element.login,
            senha: element.senha,
          })
        })
      },
      error => {
        console.log(error.message);
      }, () => {
        this.dataSource = this.users;
      });
  }

  editUser(element){
    this.isUpdate = true;
    this.idUser = element.Id;
    this.form.controls.nome.setValue(element.nome);
    this.form.controls.email.setValue(element.email);
    this.form.controls.login.setValue(element.login);
   }

   deleteUser(element){
    this.unSubscribe = this.userService.deleteUser(element.Id).subscribe(
      response => {
          this.msgSucesso("Usuario Excluído Com Sucesso!", "Fechar")
      },
      err => {
        console.log(err);
      },
      () => {
        this.listaUsuarios();
      })
   }


}
