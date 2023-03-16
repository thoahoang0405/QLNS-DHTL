<template>
    <div class="notification-wrap">
            <div class="notification">
                <div class="warring">
                    <i class="fa fa-exclamation-triangle"></i>
                    <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn lưu thông tin?</div>
                </div>
                <div class="btn-wrap">
                    <div class="btnNotifi btn-secondary" @click="CancelNotifi">Hủy</div>
                    <div class="btnNotifi btn-primary" @click="noClick">Không</div>
                </div>
            </div>
        </div>
</template>

<script>
     export default {
        data(){
            return {
                // isShowNotifi: false
            }
        },
        components: {
        },

        methods: {
            noClick() {
                this.$emit('closeNotifi',false)
            },
            CancelNotifi() {
                this.$emit('cancelNotifi',false)
            }
        }
    }
</script>