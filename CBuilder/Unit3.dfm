object Form3: TForm3
  Left = 0
  Top = 0
  Caption = 'Form3'
  ClientHeight = 299
  ClientWidth = 635
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object btnMemcpy: TButton
    Left = 8
    Top = 8
    Width = 75
    Height = 25
    Caption = 'memcpy'
    TabOrder = 0
    OnClick = btnMemcpyClick
  end
  object btnMemcpySse: TButton
    Left = 89
    Top = 8
    Width = 75
    Height = 25
    Caption = 'MemcpySse'
    TabOrder = 1
    OnClick = btnMemcpySseClick
  end
  object lbxLog: TListBox
    Left = 8
    Top = 39
    Width = 619
    Height = 252
    ItemHeight = 13
    TabOrder = 2
  end
  object Button1: TButton
    Left = 552
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Clear Log'
    TabOrder = 3
    OnClick = Button1Click
  end
end
