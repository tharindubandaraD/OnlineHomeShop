/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Product_cardComponent } from './product_card.component';

describe('Product_cardComponent', () => {
  let component: Product_cardComponent;
  let fixture: ComponentFixture<Product_cardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Product_cardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Product_cardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
