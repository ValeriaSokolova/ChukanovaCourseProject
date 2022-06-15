CREATE TABLE окюярхмйю(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
хяонкмхрекэ CHAR(20),
юкэанл CHAR(20),
пюглеп_окюярхмйх CHAR(20),
бпелъ_опнхцпшбюмхъ CHAR(20),
дюрю_бшосяйю DATE
)
CREATE TABLE ярсдхъ(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
мюгбюмхе CHAR(20),
цнпнд CHAR(20),
хмдейя INT,
скхжю CHAR(20),
днл INT,
йбюпрхпю INT
)

CREATE TABLE рхо_окюярхмйх(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
рхо_окюярхмйх CHAR(20)
)
INSERT INTO рхо_окюярхмйх(рхо_окюярхмйх) VALUES ('цпюлокюярхмйю');
INSERT INTO рхо_окюярхмйх(рхо_окюярхмйх) VALUES ('бхмхкнбюъ');
INSERT INTO рхо_окюярхмйх(рхо_окюярхмйх) VALUES ('окюярхмйю');
Select*from рхо_окюярхмйх

CREATE TABLE жемю(
id_m INT NOT NULL PRIMARY KEY IDENTITY(1,1),
жемю CHAR(40)
)
INSERT INTO жемю(жемю) VALUES ('5$');
INSERT INTO жемю(жемю) VALUES ('10$');
INSERT INTO жемю(жемю) VALUES ('15$');
Select*from жемю

INSERT INTO ярсдхъ(мюгбюмхе,цнпнд,хмдейя,скхжю,днл,йбюпрхпю) VALUES ('скэрпю','бНПНМЕФ','394053','ьХЬЙНБЮ','36','18');
INSERT INTO ярсдхъ(мюгбюмхе,цнпнд,хмдейя,скхжю,днл,йбюпрхпю) VALUES ('пейнпд','бНПНМЕФ','394053','аЕЦНБЮЪ','36','118');
INSERT INTO ярсдхъ(мюгбюмхе,цнпнд,хмдейя,скхжю,днл,йбюпрхпю) VALUES ('щаах','бНПНМЕФ','394077','лНЯЙНБЯЙХИ ОП-Р','95','60');
INSERT INTO ярсдхъ(мюгбюмхе,цнпнд,хмдейя,скхжю,днл,йбюпрхпю) VALUES ('йпютр','лНЯЙБЮ','141700','оКЕУЮМНБЯЙЮЪ','17','71');
SELECT * FROM ярсдхъ


INSERT INTO  окюярхмйю(хяонкмхрекэ,юкэанл,пюглеп_окюярхмйх,бпелъ_опнхцпшбюмхъ,дюрю_бшосяйю,рхо_окюярхмйх_id,жемю_id,ярсдхъ_id) VALUES('аЮЯЙНБ','мЕ АСДС ПСЙХ РБНХ','12ЛЛ','20 ЛХМСР','20.01.2000',1,1,1)
SELECT * FROM окюярхмйю