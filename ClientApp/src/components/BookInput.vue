<script setup lang="ts">
defineProps({
  inputType: {
    type: String,
    required: false,
    default: "text",
  },
  inputValue: {
    type: String,
    required: false,
  },
  placeHolder: {
    type: String,
  },
});

defineEmits(["update:modelValue"]);
</script>

<template>
  <input
    class="appearance-none outline-none hover:bg-white w-4/5 bg-slate-100 rounded indent-4 placeholder:text-slate-600"
    :type="inputType"
    :value="inputValue"
    :placeholder="placeHolder"
    @input="$emit('update:modelValue', $event.target.value)"
  />
</template>
