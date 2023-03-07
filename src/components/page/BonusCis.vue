<template>
    <div class="bonus-form">
        <h3>Thêm mới thông tin khen thưởng</h3>
    <table>
        <tr>
            <td width="20%">Khối <span class="color-red">*</span></td>
            <td>
                <select class="w-full" name="" id="">
                    <option value="1">Lựa chọn</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                </select>
            </td>
            <td width="10%">
                Lớp <span class="color-red">*</span>
            </td>
            <td colspan="2">
                <select class="w-full" name="" id="">
                    <option value="1">Lựa chọn</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>
                Học sinh <span class="color-red">*</span>
            </td>
            <td colspan="4">
                <select class="w-full" name="" id="">
                    <option value="1">Lựa chọn</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>
                Hình thức khen thưởng <span class="color-red">*</span>
            </td>
            <td colspan="4">
                <select class="w-full" name="" id="">
                    <option value="1">Lựa chọn</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>
                Nơi khen thưởng <span class="color-red">*</span>
            </td>
            <td colspan="4">
                <select class="w-full" name="" id="">
                    <option value="1">Lựa chọn</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>
                Ngày khen thưởng <span class="color-red">*</span>
            </td>
            <td><input type="date" name="" id=""></td>
            <td>
                <input type="checkbox" name="" id="">
            </td>
            <td colspan="2">
                Được lưu vào học bạ
            </td>
        </tr>
        <tr>
            <td>
                Nội dung khen thưởng <span class="color-red">*</span>
            </td>
            <td colspan="4">
                <input type="text" name="" id="">
            </td>
        </tr>
        <tr>
            <td class="btn-group" colspan="5">
                <button  class="btn-action" >
                    Lưu
                </button>
                <button @click="thongbao" class="btn-action" >
                    Đóng
                </button>
            </td>
        </tr>
    </table>
    </div>
</template>
<script>
export default {
  data() {
    return {
      
    };
  },
  methods: {
   thongbao(){
    alert("Xác nhận đóng")
   }
    },
 
};
</script>
<style scoped>
.bonus-form{
    padding-left: 20px;
}
table,
tr,
td {
    border: none;
    padding: 5px;
    background-color: white;
}

.width-half {
    width: 50%;
}

.color-red {
    color: red
}

.btn-action {
    width: 100px;
    height: 50px;
    background: #3A98B9;
    margin-right: 10px;
    border: none;
    color: white;
    font-weight: bold;
    border-radius: 10px;
}
.btn-group{
    text-align: center;
}
.w-full{
    width: 100%;
    height: 35px;
}
</style>