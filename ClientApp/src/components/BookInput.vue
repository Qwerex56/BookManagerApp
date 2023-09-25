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
    :type="inputType"
    :value="inputValue"
    :placeholder="placeHolder"
    @input="$emit('update:modelValue', $event.target.value)"
  />
</template>
