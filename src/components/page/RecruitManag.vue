<template>
    <div class="body">
        <h3 class="header-bd">Quản lý tuyển dụng</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input type="text" class="search" placeholder="Tìm kiếm " />
          <div class="icon-search icon"></div>
        </div>
      
      </div>
      <div class="button-function">
        <div class="add">
          <button class="btn-add btn-hover-blue">+ Thêm tin tuyển dụng</button>
        </div>

        <!-- <button class="btn-excel">
          <div class="icon icon-excel">
            <div class="tooltip-excel">Xuất ra excel</div>
          </div>
        </button> -->
        
      </div>
    </div>
    <div class="body-recruit">
        <div class="item-row">
            <div class="item-recruit">
              <div class="body-rec">
                <div>
                  <img class="image" src="../../assets/img/anh1.jpg" alt="">
                </div>
                <h3 class="header-rec">Giảng viên môn Web</h3>
                <div class="title-name">Đại học thủy lợi</div>
                <div>Chứng chỉ đào tạo: Thạc sĩ</div>
                <div class="icon">
                  <i class="fa fa-trash-alt"></i>
                </div>
              </div>
            </div>
            <div class="item-recruit"></div>
            <div class="item-recruit"></div>
        </div>
    </div>
    </div>
   
</template>
<style scoped>
.item-row{
    display: flex;
    justify-content: space-between;
}
.item-recruit{
    border-radius: 4px;
    width: 350px;
    height: 350px;
    background-color: #fff;
    padding: 8px;
}
.image {
  margin-top: 10px;
  border-radius: 4px;
  width: 100%;
  height: 100%;
}
.title-name {
  margin-bottom: 10px;
}
.icon {
  
}
</style>

<script>
// import { MessageOutlined } from '@ant-design/icons-vue';

</script>