<template>
    <div class="body">
      <h3 class="header-bd">Quản lý hợp đồng</h3>
      <div class="body-header">
        <div class="row-input">
          <div class="input">
            <input type="text" class="search" placeholder="Tìm kiếm " />
            <div class="icon-search icon"></div>
          </div>
        </div>
        <div class="button-function">
          <div class="add">
            <button class="btn-add btn-hover-blue">+ Thêm hợp đồng</button>
          </div>
  
          <!-- <button class="btn-excel">
            <div class="icon icon-excel">
              <div class="tooltip-excel">Xuất ra excel</div>
            </div>
          </button> -->
        </div>
      </div>
      <div id="body-recruit">
        <div class="body-recruit">
       
        <div class="item-row">
          <div class="item-recruit">
            <div class="body-rec">
              <div>
                <img class="image" src="../../assets/img/anh1.jpg" alt="" />
              </div>
              <h3 class="header-h3">Giảng viên môn Web</h3>
              <div class="title-name">Đại học thủy lợi</div>
              <div>Chứng chỉ đào tạo: Thạc sĩ</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>
            </div>
          </div>
          <div class="item-recruit">
            <div class="body-rec">
              <div>
                <img class="image" src="../../assets/img/anh1.jpg" alt="" />
              </div>
              <h3 class="header-h3">Giảng viên môn Web</h3>
              <div class="title-name">Đại học thủy lợi</div>
              <div>Chứng chỉ đào tạo: Thạc sĩ</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>
            </div>
          </div>
          <div class="item-recruit">
            <div class="body-rec">
              <div>
                <img class="image" src="../../assets/img/anh1.jpg" alt="" />
              </div>
              <h3 class="header-h3">Giảng viên môn Web</h3>
              <div class="title-name">Đại học thủy lợi</div>
              <div>Chứng chỉ đào tạo: Thạc sĩ</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>
            </div>
          </div>
          <div class="item-recruit">
            <div class="body-rec">
              <div>
                <img class="image" src="../../assets/img/anh1.jpg" alt="" />
              </div>
              <h3 class="header-h3">Giảng viên môn Web</h3>
              <div class="title-name">Đại học thủy lợi</div>
              <div>Chứng chỉ đào tạo: Thạc sĩ</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>
            </div>
          </div>
          <div class="item-recruit">
            <div class="body-rec">
              <div>
                <img class="image" src="../../assets/img/anh1.jpg" alt="" />
              </div>
              <h3 class="header-h3">Giảng viên môn Web</h3>
              <div class="title-name">Đại học thủy lợi</div>
              <div>Chứng chỉ đào tạo: Thạc sĩ</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>
            </div>
          </div>
          <div class="item-recruit">
            <div class="body-rec">
              <div>
                <img class="image" src="../../assets/img/anh1.jpg" alt="" />
              </div>
              <h3 class="header-h3">Giảng viên môn Web</h3>
              <div class="title-name">Đại học thủy lợi</div>
              <div>Chứng chỉ đào tạo: Thạc sĩ</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>
            </div>
          </div>
        </div>
       </div>
      </div>
    </div>
   
  </template>
  <style scoped>
  .container {
    /* height: 50vh; */
  }
  /* #body-recruit {
    background-color: #fff;
  } */
  .body-recruit {
    margin: 0 auto;
    max-width: 1000px;
  }
  .item-row{
      display: grid;
      grid-template-columns: repeat(3,1fr);
      gap: 20px;
      /* justify-content: space-between; */
      /* flex-wrap: wrap; */
  }
  .item-recruit{
      border-radius: 4px;
      /* width: 350px; */
      background-color: #fff;
      padding: 8px;
      /* overflow-y: hidden; */
  }
  .image {
    border-radius: 4px;
    width: 100%;
    height: 100%;
  }
  .title-name {
    margin-bottom: 10px;
  }
  .btn-wrap{
    display: flex;
    justify-content: flex-end;
    column-gap: 10px;
    margin-top: 10px;
  }
  .btnEdit,
  .btnDelete{
    border: 1px solid #ccc;
    padding: 6px 8px;
    border-radius: 2px;
    cursor: pointer;
  }
  
  @media screen and (max-width: 767.98px) {
    .item-row{
      display: grid;
      grid-template-columns: repeat(2,1fr);
  }
  }
  @media screen and (max-width: 600px) {
    .item-row{
      display: grid;
      grid-template-columns: 1fr;
  }
  }
  
  
  
  </style>
  
  <script>
  // import { MessageOutlined } from '@ant-design/icons-vue';
  
  </script>