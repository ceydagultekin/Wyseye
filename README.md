# Wyseye Car Project
Note: The following sections are written in English.

Bu proje, bir araba koleksiyonunun yönetimi için basit bir CRUD uygulaması sunar. Kullanıcılar, araç ekleme, listeleme, güncelleme ve silme işlemlerini API aracılığıyla veya uygulamanın arayüzü üzerinden gerçekleştirebilirler. Proje çalıştırıldığında basit bir arayüz bizi karşılar. Bu arayüzde "Add Car" butonuna tıklanarak yeni araç eklenebilir ve araçlar listelenir. Aşağıda, projenin kurulumu ve çalıştırılması için adım adım talimatlar bulunmaktadır.

## İçindekiler
- [Özellikler](#özellikler)
- [Ön Koşullar](#ön-koşullar)
- [Projeyi Çalıştırma](#projeyi-çalıştırma)
- [API Kullanımı](#api-kullanımı)
- [Örnek Arayüz Sayfası](#örnek-arayüz-sayfası)


## Özellikler
- **CRUD İşlemleri**: Kullanıcılar araç ekleyebilir, listeleyebilir, güncelleyebilir ve silebilir.
- **API Endpoint'leri**: API aracılığıyla araç bilgileri kolayca yönetilebilir.
- **Kullanıcı Arayüzü**: Basit bir kullanıcı arayüzü ile araçlar listelenebilir ve ekleme işlemleri yapılabilir.

## Ön Koşullar 
Projeyi çalıştırmadan önce aşağıdaki yazılımların sisteminizde kurulu olduğundan emin olun:
- .NET 6 veya daha güncel bir sürüm
- Docker (Docker ile çalıştırmak istiyorsanız)
- Visual Studio veya Visual Studio Code (isteğe bağlı)

## Projeyi Çalıştırma

### 1. Yerel Ortamda Çalıştırma
#### 1. Projeyi Klonlayın
Öncelikle projeyi yerel ortamınıza klonlayın:

```bash
git clone [REPO_URL]
cd WyseyeCase
```

#### 2. Bağımlılıkları yükleyin
Gerekli bağımlılıkları yüklemek için aşağıdaki komutu çalıştırın:

```bash
dotnet restore
```

#### 3. Veritabanı Bağlantı Ayarlarını Yapın
Program.cs dosyasındaki connectionString kısmını yerel veritabanı bilgilerinize göre güncelleyin. Windows Authentication veya Sql Server Authenticaiton seçenekerlerinden hangisi ile bağlanmayı seçecekseniz ona göre değerleri güncelleyin.

```bash
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True";
```

#### 4. Veritabanı Migrasyonlarını uygulayın
Veritabanını oluşturmak ve migrasyonları uygulamak için aşağıdaki komutu çalıştırın:

```bash
dotnet ef database update
```

#### 5. Uygulamayı çalıştırın
Projeyi başlatmak için aşağıdaki komutu kullanın:

```bash
dotnet run
```
Uygulama başarılı bir şekilde başlatıldığında, http://localhost:5000 adresinde çalışacaktır.

### 2. Docker ile Çalıştırma

Projeyi Docker ortamında çalıştırmak için Docker Compose dosyasını kullanabilirsiniz.
#### 1. Docker Konteynerlerini Başlatın

```bash
docker-compose up -d
```

#### 2. Konteyner Durumunu Kontrol Edin 

```bash
docker ps
```

Çalışan **sqlserver** ve **wyseyecase** konteynerlerini görebilirsiniz.

#### 3. Arayüz ve API Üzerinden Erişim Sağlayın 
- Uygulama arayüzü için http://localhost:8081
- API için: http://localhost:8081/api/cars

 
## API Kullanımı 

CarsController API endpointlerini Postman aracılığı ile kolayca test edebilirsiniz.

  **1**- CRUD işlemlerini gerçekleştirmeden önce URL kısmını şu şekilde ayarlamalısınız: https://localhost:8081/api/cars. ID'nin gerekli olduğu endpoint'lerde, URL'ye ID eklemeyi unutmayın. Aşağıdaki adımlara göz atarak doğru URL yapısını kullanabilirsiniz.

  **2**- Araç ekleme ve güncelleme sırasında Postman Body sekmesinde **raw** ve **JSON** formatını seçin. 
  
  **3**- En son olarak test işlemini gerçekleştirmek için **Send** butonuna tıklayınız.
  

### 1. Tüm Araçları Listeleme 
GET /api/cars

### 2. Id ile Araç Getirme  
GET /api/cars/{id}

### 3. Yeni Araç Ekleme  
POST /api/cars
Örnek Body (JSON) formatı:
```json
{
  "make": "Toyota",
  "model": "Corolla",
  "year": 2022,
  "licensePlate": "34ABC123"
}
```

### 4. Araç Silme  
DELETE /api/cars/{id}

### 5. Araç Güncelleme
PUT /api/cars/{id}
Örnek Body (JSON) formatı:
```json
{
  "id": 5,
  "make": "Toyota",
  "model": "Corolla",
  "year": 2022,
  "licensePlate": "34ABC123"
}
```

## Örnek Arayüz Sayfası

Arayüz sayfasında araç bilgileri aşağıdaki şekilde listelenir:

- **Araç Bilgileri Görüntüleme**: Her araç için model, yıl ve plaka bilgileri gösterilir.
- **Araç Ekleme Butonu**: "Add Car" butonu ile yeni bir araç ekleyebilirsiniz.

Uygulama çalıştığındaki arayüz:

![car1](https://github.com/user-attachments/assets/26daee62-7419-4ce7-97e0-2bac16c8a925)

Eklenmiş araçların listelenmiş görüntüsü:

![car2](https://github.com/user-attachments/assets/5fbf4813-0e29-4f3e-a29b-99505e0b8cc0)



## Video Tanıtımı

Projenin nasıl çalıştığını gösteren videoyu aşağıdaki bağlantıya tıklayarak izleyebilirsiniz:

[Proje Tanıtım Videosu](https://www.youtube.com/watch?v=ZzGSMBNVMYY)



# Wyseye Car Project
This project presents a simple CRUD application for managing a car collection. Users can perform add, list, update, and delete operations through the API or the application's interface. When the project is run, a simple interface welcomes us. In this interface, new cars can be added by clicking the "Add Car" button, and cars can be listed. Below are step-by-step instructions for setting up and running the project.

## Table of Contents
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Running the Project](#running-the-project)
- [API Usage](#api-usage)
- [Sample Interface Page](#sample-interface-page)


## Features
- **CRUD Operations**: Users can add, list, update, and delete cars.
- **API Endpoints**:  Car information can be easily managed through the API.
- **User Interface**: Cars can be listed and added with a simple user interface.

## Prerequisites
Before running the project, ensure that the following software is installed on your system:
- .NET 6 or a newer version
- Docker (if you want to run it with Docker)
- Visual Studio or Visual Studio Code (optional)

## Running the Project

### 1. Running in Local Environment
#### 1. Clone the Project
First, clone the project to your local environment:

```bash
git clone [REPO_URL]
cd WyseyeCase
```

#### 2. Install Dependencies
Run the following command to install the required dependencies:

```bash
dotnet restore
```

#### 3. Configure Database Connection Settings
Update the connectionString section in Program.cs with your local database information. Depending on whether you choose Windows Authentication or SQL Server Authentication, update the values accordingly.

```bash
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True";
```

#### 4. Apply Database Migrations
Run the following command to create the database and apply migrations:

```bash
dotnet ef database update
```

#### 5. Run the Application
Use the following command to start the project:

```bash
dotnet run
```
When the application is successfully started, it will run at http://localhost:5000.

### 2. Running with Docker

You can use the Docker Compose file to run the project in a Docker environment.
#### 1.  Start Docker Containers

```bash
docker-compose up -d
```

#### 2. Check Container Status

```bash
docker ps
```

You should see the running **sqlserver** and **wyseyecase** containers.

#### 3. Access via Interface and API
- For the application interface: http://localhost:8081
- For the API: http://localhost:8081/api/cars

 
## API Usage

You can easily test the CarsController API endpoints using Postman.

  **1**- Before performing CRUD operations, set the URL as follows: https://localhost:8081/api/cars. Remember to append the ID to the URL for endpoints where it's required. Refer to the steps below to use the correct URL structure.

  **2**- During car addition and update, select raw and JSON format in the Body tab of Postman.
  
  **3**- Finally, click the Send button to perform the test.
  

### 1. List All Cars
GET /api/cars

### 2. Get Car by Id
GET /api/cars/{id}

### 3.  Add New Car  
POST /api/cars
Example Body in JSON format:
```json
{
  "make": "Toyota",
  "model": "Corolla",
  "year": 2022,
  "licensePlate": "34ABC123"
}
```

### 4. Delete Car
DELETE /api/cars/{id}

### 5. Update Car
PUT /api/cars/{id}
Example Body in JSON format:
```json
{
  "id": 5,
  "make": "Toyota",
  "model": "Corolla",
  "year": 2022,
  "licensePlate": "34ABC123"
}
```

## Sample Interface Page

The interface page displays car information as follows:

- **Viewing Car Information**: For each car, the model, year, and license plate information are shown.
- **Add Car Button**: You can add a new car using the "Add Car" button.

The interface when the application is running:

![car1](https://github.com/user-attachments/assets/26daee62-7419-4ce7-97e0-2bac16c8a925)

List of added cars:

![car2](https://github.com/user-attachments/assets/5fbf4813-0e29-4f3e-a29b-99505e0b8cc0)



## Video Presentation

You can watch the video demonstrating how the project works by clicking the link below:

[Project Presentation Video](https://www.youtube.com/watch?v=ZzGSMBNVMYY)
