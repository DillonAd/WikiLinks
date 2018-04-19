import { Component, OnInit } from '@angular/core';
import { ArticleComponent } from '../article/article.component';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.css']
})
export class EditorComponent implements OnInit {

  public EditedArticle:string;

  constructor() { }

  ngOnInit() {
  }

}
