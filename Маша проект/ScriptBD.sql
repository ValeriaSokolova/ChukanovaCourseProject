CREATE TABLE ���������(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
����������� CHAR(20),
������ CHAR(20),
������_��������� CHAR(20),
�����_������������ CHAR(20),
����_������� DATE
)
CREATE TABLE ������(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
�������� CHAR(20),
����� CHAR(20),
������ INT,
����� CHAR(20),
��� INT,
�������� INT
)

CREATE TABLE ���_���������(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
���_��������� CHAR(20)
)
INSERT INTO ���_���������(���_���������) VALUES ('�������������');
INSERT INTO ���_���������(���_���������) VALUES ('���������');
INSERT INTO ���_���������(���_���������) VALUES ('���������');
Select*from ���_���������

CREATE TABLE ����(
id_m INT NOT NULL PRIMARY KEY IDENTITY(1,1),
���� CHAR(40)
)
INSERT INTO ����(����) VALUES ('5$');
INSERT INTO ����(����) VALUES ('10$');
INSERT INTO ����(����) VALUES ('15$');
Select*from ����

INSERT INTO ������(��������,�����,������,�����,���,��������) VALUES ('������','�������','394053','�������','36','18');
INSERT INTO ������(��������,�����,������,�����,���,��������) VALUES ('������','�������','394053','�������','36','118');
INSERT INTO ������(��������,�����,������,�����,���,��������) VALUES ('����','�������','394077','���������� ��-�','95','60');
INSERT INTO ������(��������,�����,������,�����,���,��������) VALUES ('�����','������','141700','������������','17','71');
SELECT * FROM ������


INSERT INTO  ���������(�����������,������,������_���������,�����_������������,����_�������,���_���������_id,����_id,������_id) VALUES('������','�� ���� ���� ����','12��','20 �����','20.01.2000',1,1,1)
SELECT * FROM ���������