import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';

const routes: Routes = [
  {
path: '', //localhost:4200
component: HomeComponent,
pathMatch: 'full'
  },
  {
    path: '',//localhost:4200/members
    canActivate: [AuthGuard], 
    runGuardsAndResolvers: 'always',
    children: [
      {path: 'members' ,component: MemberListComponent},
      {path: 'members/:id' ,component: MemberDetailComponent},
      {path: 'lists' ,component: ListsComponent},
      {path: 'messages' ,component: MessagesComponent},
    ] 
   },

  {
    path:'**' ,//localhost:4200/anything
    component: HomeComponent,
    pathMatch: 'full'
  }

  // {
  //  path: 'members',//localhost:4200/members
  //  component: MemberListComponent, 
  //  canActivate: [AuthGuard],
  //  children: [
  //   {
  //   path: ':id', //localhost:4200/members/1
  //   component: MemberDetailComponent
  //  }]   
  // },
  // {
  //   path: 'members/:id',//localhost:4200/members/1
  //   component: MemberDetailComponent,
  //   canActivate: [AuthGuard],
  // },
  // {
  //   path: 'lists',//localhost:4200/lists
  //   component: ListsComponent,
  //   canActivate: [AuthGuard],
  // },
  // {
  //   path: 'messages',//localhost:4200/messages
  //   component: MessagesComponent,
  //   canActivate: [AuthGuard],
  // },



];






@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
