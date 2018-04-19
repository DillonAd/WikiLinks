import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {

  public title:string;
  public content:string;
  public lastModifiedBy:string;
  public lastModifiedDate:Date;

  constructor() { }

  ngOnInit() {
  }

}
